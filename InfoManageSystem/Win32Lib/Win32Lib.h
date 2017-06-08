#pragma once
#include"stdafx.h"
#include<string>
#include"md5_encode.h"
using namespace std;
string TCHAR2STRING(TCHAR* STR);

extern "C" __declspec(dllexport) TCHAR* __stdcall EncryptStringW(TCHAR* in_string);
