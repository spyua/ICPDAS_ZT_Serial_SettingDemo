using System;
using System.Runtime.InteropServices;

namespace Model
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ModBusTCPModel
    {
        // Header
        [MarshalAs(UnmanagedType.I2)]
        public short TransactionID;
        [MarshalAs(UnmanagedType.I2)]
        public short ProtocalID;
        [MarshalAs(UnmanagedType.I2)]
        public short Length;
        // Data
        [MarshalAs(UnmanagedType.I1)]
        public byte SlaveAddress;
        [MarshalAs(UnmanagedType.I1)]
        public byte FunctionCode;
        [MarshalAs(UnmanagedType.I2)]
        public short StartRegisterAddr;
        [MarshalAs(UnmanagedType.I1)]
        public byte Data;


        public override string ToString()
        {
            return TransactionID.ToString() + "@" + ProtocalID.ToString() + "@ " + Length.ToString() + "@" + SlaveAddress.ToString() + "@" + FunctionCode.ToString() + "@" + StartRegisterAddr.ToString() + "@" + Data.ToString(); ;
        }
    }
}
