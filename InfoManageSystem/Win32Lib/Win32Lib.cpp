// Win32Lib.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include"Win32Lib.h"

string TCHAR2STRING(TCHAR* STR)
{
	int iLen = WideCharToMultiByte(CP_ACP, 0, STR, -1, NULL, 0, NULL, NULL);
	char* chRtn = new char[iLen * sizeof(char)];
	WideCharToMultiByte(CP_ACP, 0, STR, -1, chRtn, iLen, NULL, NULL);
	string str(chRtn);
	return str;
}

TCHAR* __stdcall EncryptStringW(TCHAR* in_string)
{
	string src = TCHAR2STRING(in_string);
	Md5Encode encode_obj;
	string ret = encode_obj.Encode(src);
	TCHAR wc[MAX_PATH];
	MultiByteToWideChar(CP_ACP, 0, (LPCSTR)ret.c_str(), -1, wc, MAX_PATH);
	return wc;
}


