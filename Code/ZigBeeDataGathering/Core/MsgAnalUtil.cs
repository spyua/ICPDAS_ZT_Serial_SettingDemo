using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Core
{
    public static class MsgAnalUtil
    {



        public static object RawDeserialize(this byte[] byteData, Type type, bool is_ConvertEndian = false)
        {
            try
            {
                int rawsize = Marshal.SizeOf(type);

                if (rawsize > byteData.Length)
                    return null;

                // ' ==============反轉===================
                if (is_ConvertEndian == true)
                    ConvertEndian(byteData, type);
                // ' ====================================

                IntPtr buffer = Marshal.AllocHGlobal(rawsize);
                Marshal.Copy(byteData, 0, buffer, rawsize);
                object structureData = Marshal.PtrToStructure(buffer, type);

                // 釋放
                Marshal.FreeHGlobal(buffer);

                return structureData;
            }
            catch
            {
                throw;
            }
        }

        private static byte[] ConvertEndian(byte[] byteData, Type type, int iCursor = 0)
        {
            int iMLength = 0;
            bool bIsArray = false;
            int iSizeConst = 0;
            Type FieldType = null;

            try
            {
                foreach (FieldInfo fi in type.GetFields())
                {
                    FieldType = fi.FieldType;

                    //取得Attribute
                    var marshal = fi.GetCustomAttribute<MarshalAsAttribute>();
                    bIsArray = (marshal.Value == UnmanagedType.ByValArray);
                    iSizeConst = marshal.SizeConst;

                    if (bIsArray)
                    {
                        //FieldType
                        Type elementType = FieldType.GetElementType();
                        for (int i = 0; i < iSizeConst; i++)
                        {
                            switch (elementType)
                            {
                                case Type byteType when byteType == typeof(byte):
                                case Type intType when intType == typeof(int):
                                case Type shortType when shortType == typeof(short):
                                case Type longType when longType == typeof(long):
                                case Type floatType when floatType == typeof(float):
                                case Type doubleType when doubleType == typeof(double):
                                    {
                                        // 需要進行轉換
                                        iMLength = Marshal.SizeOf(elementType);
                                        Array.Reverse(byteData, iCursor, iMLength);
                                        iCursor += iMLength;
                                        break;
                                    }
                                case Type charType when charType == typeof(byte):
                                    {
                                        iCursor += 1;
                                        break;
                                    }
                                case Type charType when charType == typeof(char):
                                    {
                                        iCursor += 1;
                                        break;
                                    }
                                case Type stringType when stringType == typeof(string):
                                    {
                                        break;
                                    }

                                default:
                                    {
                                        ConvertEndian(byteData, elementType, iCursor);
                                        break;
                                    }
                            }
                        }
                    }
                    else
                    {//非陣列
                        switch (FieldType)
                        {
                            case Type byteType when byteType == typeof(byte):
                            case Type intType when intType == typeof(int):
                            case Type shortType when shortType == typeof(short):
                            case Type longType when longType == typeof(long):
                            case Type floatType when floatType == typeof(float):
                            case Type doubleType when doubleType == typeof(double):
                                {
                                    // 需要進行轉換
                                    iMLength = Marshal.SizeOf(FieldType);
                                    Array.Reverse(byteData, iCursor, iMLength);
                                    iCursor += iMLength;
                                    break;
                                }
                            case Type byteType when byteType == typeof(byte[]):
                            case Type charType when charType == typeof(char):
                            case Type stringType when stringType == typeof(string):
                                {
                                    iMLength = iSizeConst;
                                    iCursor += iMLength;
                                    break;
                                }

                            default:
                                {
                                    ConvertEndian(byteData, FieldType, iCursor);
                                    break;
                                }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return byteData;
        }
    }
}
