using System;

public class UtilityFuncs {
    public byte[] ConvertStringToByteArray(string str) {
        byte[] byteArray = new byte[str.Length];

        for (int i = 0; i < str.Length; i++) {
            byteArray[i] = Convert.ToByte(str[i]);
        }

        return byteArray;
    }
}
