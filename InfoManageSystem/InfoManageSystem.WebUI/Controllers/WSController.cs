using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.WebSockets;
using Newtonsoft.Json;
using InfoManageSystem.Service.IService;
using InfoManageSystem.Domain.Entities;
namespace InfoManageSystem.WebUI.Controllers
{
    [RoutePrefix("api/WS")]
    public class WSController : ApiController
    {
        public static  Dictionary<string, WebSocket> CONNECT_POOL = new Dictionary<string, WebSocket>();
     /*   private IWarningService warningService;
        public WSController(IWarningService warningService)
        {
            this.warningService = warningService;
        }*/
        [Route]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            if(HttpContext.Current.IsWebSocketRequest)
            {
                HttpContext.Current.AcceptWebSocketRequest(HandlerSocket);
            }
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        private async Task HandlerSocket(AspNetWebSocketContext arg)
        {
            WebSocket socket = arg.WebSocket;
            string user = arg.QueryString["user"].ToString();
            if (!CONNECT_POOL.ContainsKey(user))
                CONNECT_POOL.Add(user, socket);
            else if (CONNECT_POOL[user] != socket)
                CONNECT_POOL[user] = socket;
            while(true)
            {
                var buffer = new ArraySegment<byte>(new byte[1024]);
                var receivedResult = await socket.ReceiveAsync(buffer, CancellationToken.None);//对web socket进行异步接收数据
                if (receivedResult.MessageType == WebSocketMessageType.Close)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.Empty, string.Empty, CancellationToken.None);//如果client发起close请求，对client进行ack
                    CONNECT_POOL.Remove(user);
                    break;
                }
                if (socket.State == System.Net.WebSockets.WebSocketState.Open)
                {
                    string recvMsg = Encoding.UTF8.GetString(buffer.Array, 0, receivedResult.Count);
                    var recvBytes = Encoding.UTF8.GetBytes(recvMsg);
                    var sendBuffer = new ArraySegment<byte>(recvBytes);
               /*     foreach (var innerSocket in _sockets)//当接收到文本消息时，对当前服务器上所有web socket连接进行广播
                    {
                        if (innerSocket != socket)
                        {
                            await innerSocket.SendAsync(sendBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
                        }
                    }
                    */
                }
            }
        }

        public static  void SendWarnings(IWarningService warningService)
        {
            IEnumerable<Warning> warnList = warningService.GetWarning().ToList();
            var warning = from warn in warnList
                          select new
                          {
                              GoodsId = warn.GoodsId,
                              GoodName = warn.Goods.Name,
                              MinStorage = warn.Goods.minNum,
                              CurrentStorage = warn.Goods.GoodsStorages.Sum(g => g.Quantity)
                          };
            string warningMessage = JsonConvert.SerializeObject(warning);
            var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(warningMessage));
            foreach (WebSocket socket in CONNECT_POOL.Values)
            {
                if(socket.State == WebSocketState.Open)
                     socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
