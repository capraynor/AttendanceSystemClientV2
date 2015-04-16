using System;
using System.IO;
using System.Runtime.InteropServices;

namespace AttendanceSystemClientV2.Helpers {


    public class HdFingerprintHelper {
        private const int FP_OK = 0x00;
        protected IntPtr m_hFpDrive;

        [DllImport ("fplib.dll")]
        public static extern IntPtr FpOpenUsb ( UInt32 nAddr, UInt32 timeout ); // naddr = 0xFFFFFFFF



        [DllImport ("fplib.dll")]
        public static extern int FpCloseUsb ( IntPtr fpHandle );



        [DllImport ("fplib.dll")]
        public static extern int FpGetImage ( IntPtr fpHandle, UInt32 timeout );



        [DllImport ("fplib.dll")]
        public static extern int FpGenChar ( IntPtr fpHandle, Byte nBufferId, UInt32 timeout );



        [DllImport ("fplib.dll")]
        public static extern int FpMatch ( IntPtr fpHandle, ref UInt16 pScore, UInt32 timeout );



        [DllImport ("fplib.dll")]
        public static extern int FpSearch ( IntPtr fpHandle, Byte nBufferId, UInt16 nStartPage, UInt16 nPageNum,
            ref UInt16 pPageId, ref UInt16 pScore, UInt32 timeout );




        [DllImport ("fplib.dll")]
        public static extern int FpRegModel ( IntPtr fpHandle, UInt32 timeout );



        [DllImport ("fplib.dll")]
        public static extern int FpStoreChar ( IntPtr fpHandle, Byte nBufferId, UInt16 nPageId, UInt32 timeout );



        [DllImport ("fplib.dll")]
        public static extern int FpLoadChar ( IntPtr fpHandle, Byte nBufferId, UInt16 nPageId, UInt32 timeout );



        [DllImport ("fplib.dll")]
        public static extern int FpValidTempleteNum ( IntPtr fpHandle, ref UInt16 pNum, UInt32 timeout );



        [DllImport ("fplib.dll")]
        public static extern int FpUpBMPFile ( IntPtr fpHandle, string pFile, UInt32 timeout );

        [DllImport ("fplib.dll")]
        public static extern int FpEmpty ( IntPtr fpHandle, UInt32 timeout );

        [DllImport ("fplib.dll")]
        public static extern int FpUpChar ( IntPtr fpHandle, Byte nBufferId, byte[] pBuf, int nBufSize,
            ref int pBytesReturned, UInt32 timeout );

        [DllImport ("fplib.dll")]
        public static extern int FpDownChar ( IntPtr fpHandlePtr, Byte nBufferId, byte[] pBuf, int nBufSize,
            UInt32 timeout );






        //下面是自定义函数区段
        /// <summary>
        /// 第二次指纹登记
        /// </summary>
        /// <param name="Filename">指纹图像保存位置 （BMP）</param>
        /// <param name="fpHandlePtr">指纹设备句柄 FpOpenusb的返回值</param>
        /// <param name="timeout">最长等待时间 默认为永远不超时</param>
        /// <returns>状态码 请参照状态码表 </returns>
        public static int Enroll_1st ( string Filename, IntPtr fpHandlePtr, uint timeout = 0 ) {
            int stat = 0;
            do {
                stat = FpGetImage (fpHandlePtr, timeout);
            } while (stat != 0 && stat == 2);
            if (stat != 0) return stat;

            try {
                if (File.Exists (Filename)) {
                    File.Delete (Filename);
                }
                stat = FpUpBMPFile (fpHandlePtr, Filename, timeout);
                if (stat != 0) return stat;
            } catch (Exception) {

            }
            FpGenChar (fpHandlePtr, 1, timeout);
            return stat;
        }
        /// <summary>
        /// 第二次指纹登记
        /// </summary>
        /// <param name="filename">指纹图像保存位置 （BMP）</param>
        /// <param name="fpHandlePtr">指纹设备句柄</param>
        /// <param name="timeout">超时 默认为永远不超时</param>
        /// <returns>状态码 请参照状态码表 </returns>
        public static int Enroll_2nd ( string filename, IntPtr fpHandlePtr, uint timeout = 0 ) {
            int stat = 0;
            do {
                stat = FpGetImage (fpHandlePtr, timeout);
            } while (stat != 0 && stat == 2);
            if (stat != 0) return stat;
            try {
                if (File.Exists (filename)) {
                    File.Delete (filename);
                }
                stat = FpUpBMPFile (fpHandlePtr, filename, timeout);
                if (stat != 0) return stat;
            } catch (Exception) {

            }
            FpGenChar (fpHandlePtr, 2, timeout);
            return stat;
        }
        /// <summary>
        /// 获得指纹字符串
        /// </summary>
        /// <param name="fpHandlePtr">指纹仪设备的句柄</param>
        /// <param name="fpString">指纹字符串【引用】</param>
        /// <param name="timeout">等待时间 默认为0</param>
        /// <returns>状态码 具体请参考状态码说明文件</returns>
        public static int GenerateString ( IntPtr fpHandlePtr, ref string fpString, uint timeout = 0 ) {
            int stat = 0;
            int fingerRawLength = 0;
            stat = FpRegModel (fpHandlePtr, timeout);
            if (stat != 0) return stat; // 调用指纹库
            byte[] fingerRawBytes = new byte[512];
            stat = FpUpChar (fpHandlePtr, 1, fingerRawBytes, 512, ref fingerRawLength, timeout);
            if (stat != 0) return stat; // 调用指纹库
            //byte[] newBytes = new byte[fingerRawLength];
            //Array.Copy(fingerRawBytes , 0 , newBytes , 0 , fingerRawLength );
            //fingerRawBytes = newBytes; // todo : 截取出已经下载的那部分
            string fingerBase64String = Convert.ToBase64String (fingerRawBytes);
            fpString = fingerBase64String;
            return stat;
        }
        /// <summary>
        /// 该函数会阻塞线程 用来提醒用户将手指离开指纹仪并避免出现错误 
        /// </summary>
        /// <param name="fpHandlePtr"> 指纹仪句柄</param>
        /// <param name="timeout">等待时间</param>
        public static void LiftUrFinger ( IntPtr fpHandlePtr, uint timeout = 0 ) {
            int stat = 0;
            do {
                stat = FpGetImage (fpHandlePtr, timeout);
            } while (stat == 0);
        }

        //指纹验证部分
        public static int Download1Fingerprint ( IntPtr fpHandlePtr, string fingerprintString, UInt16 id, uint timeout = 0 ) {
            int stat = 0;
            byte[] fingerPrintRawData = Convert.FromBase64String (fingerprintString);
            stat = FpDownChar (fpHandlePtr, 1, fingerPrintRawData, 512, timeout);
            if (stat != 0) return stat;
            stat = FpStoreChar (fpHandlePtr, 1, id, 3000);
            return stat;
        }

        public static int StartVerify ( IntPtr fpHandlePtr, string filename, ref UInt16 fingerId, ref ushort score, UInt32 timeout = 0 ) {
            UInt16 fingerprintNumbers = 0; // 指纹仪中的总数
            int stat = 0;
            do {
                stat = FpGetImage (fpHandlePtr, timeout);
            } while (stat != 0 && stat == 2);
            FpUpBMPFile (fpHandlePtr, filename, timeout);
            if (stat != 0) return stat;
            stat = FpValidTempleteNum (fpHandlePtr, ref fingerprintNumbers, timeout); // 获取总数
            if (stat != 0) return stat;

            // stat = FpUpBMPFile(fpHandlePtr, filename, timeout); // 上传图片
            if (stat != 0) return stat;
            stat = FpGenChar (fpHandlePtr, 1, timeout);
            if (stat != 0) return stat;
            stat = FpSearch (fpHandlePtr, 1, 0, Convert.ToUInt16 (fingerprintNumbers), ref fingerId, ref  score, timeout);
            //if (stat != 0 && stat != 9) return stat; // 错误码9：没有搜索到指纹
            //else
            //{
            //    return 0;
            //}
            return stat;
        }

    }
}
