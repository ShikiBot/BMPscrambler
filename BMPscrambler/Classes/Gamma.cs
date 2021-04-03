using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPscrambler.Classes
{
    class Gamma
    {
        public int[] Code(int[] message, int seed)
        {
            int key = LFSR(seed, "x8+x4+x3+x2+1");
            for (int i = 0; i < message.Length; i++)
            {
                message[i] = (message[i] + key) % 256;
                key = LFSR(key, "x8+x4+x3+x2+1");
            }
            return message;
        }

        enum Byte
        {
            Digit0 = 1,
            Digit1 = 1 << 1,
            Digit2 = 1 << 2,
            Digit3 = 1 << 3,
            Digit4 = 1 << 4,
            Digit5 = 1 << 5,
            Digit6 = 1 << 6,
            Digit7 = 1 << 7,
            Digit8 = 1 << 8,
            Digit9 = 1 << 9,
            Digit10 = 1 << 10,
            Digit11 = 1 << 11,
            Digit12 = 1 << 12,
            Digit13 = 1 << 13,
            Digit14 = 1 << 14,
            Digit15 = 1 << 15,
            Digit16 = 1 << 16,
            Digit17 = 1 << 17,
            Digit18 = 1 << 18,
            Digit19 = 1 << 19,
            Digit20 = 1 << 20,
            Digit21 = 1 << 21,
            Digit22 = 1 << 22,
            Digit23 = 1 << 23,
            Digit24 = 1 << 24,
            Digit25 = 1 << 25,
            Digit26 = 1 << 26,
            Digit27 = 1 << 27,
            Digit28 = 1 << 28,
            Digit29 = 1 << 29,
            Digit30 = 1 << 30,
            Digit31 = 1 << 31
        }

        public int LFSR(int seed, string formula)
        {
            formula = formula.Replace(" ", "");
            string[] frml = formula.ToLower().Split('+');
            int length = Convert.ToInt32(frml[0].Remove(0,1));
            while (seed > Math.Pow(2, length)) seed >>= 1;
            int bn = seed & (1 << Convert.ToInt32(frml[1].Remove(0, 1))) >> Convert.ToInt32(frml[1].Remove(0, 1));
            
            for (int i = 2; i < frml.Length; i++)
                switch (frml[i])
                {
                    case "x29": bn ^= (seed & (int)Byte.Digit29) >> 29; break;
                    case "x28": bn ^= (seed & (int)Byte.Digit28) >> 28; break;
                    case "x27": bn ^= (seed & (int)Byte.Digit27) >> 27; break;
                    case "x26": bn ^= (seed & (int)Byte.Digit26) >> 26; break;
                    case "x25": bn ^= (seed & (int)Byte.Digit25) >> 25; break;
                    case "x24": bn ^= (seed & (int)Byte.Digit24) >> 24; break;
                    case "x23": bn ^= (seed & (int)Byte.Digit23) >> 23; break;
                    case "x22": bn ^= (seed & (int)Byte.Digit22) >> 22; break;
                    case "x21": bn ^= (seed & (int)Byte.Digit21) >> 21; break;
                    case "x20": bn ^= (seed & (int)Byte.Digit20) >> 20; break;
                    case "x19": bn ^= (seed & (int)Byte.Digit19) >> 19; break;
                    case "x18": bn ^= (seed & (int)Byte.Digit18) >> 18; break;
                    case "x17": bn ^= (seed & (int)Byte.Digit17) >> 17; break;
                    case "x16": bn ^= (seed & (int)Byte.Digit16) >> 16; break;
                    case "x15": bn ^= (seed & (int)Byte.Digit15) >> 15; break;
                    case "x14": bn ^= (seed & (int)Byte.Digit14) >> 14; break;
                    case "x13": bn ^= (seed & (int)Byte.Digit13) >> 13; break;
                    case "x12": bn ^= (seed & (int)Byte.Digit12) >> 12; break;
                    case "x11": bn ^= (seed & (int)Byte.Digit11) >> 11; break;
                    case "x10": bn ^= (seed & (int)Byte.Digit10) >> 10; break;
                    case "x9": bn ^= (seed & (int)Byte.Digit9) >> 9; break;
                    case "x8": bn ^= (seed & (int)Byte.Digit8) >> 8; break;
                    case "x7": bn ^= (seed & (int)Byte.Digit7) >> 7; break;
                    case "x6": bn ^= (seed & (int)Byte.Digit6) >> 6; break;
                    case "x5": bn ^= (seed & (int)Byte.Digit5) >> 5; break;
                    case "x4": bn ^= (seed & (int)Byte.Digit4) >> 4; break;
                    case "x3": bn ^= (seed & (int)Byte.Digit3) >> 3; break;
                    case "x2": bn ^= (seed & (int)Byte.Digit2) >> 2; break;
                    case "1": bn ^= seed & (int)Byte.Digit1; break;
                }                          
            return (bn << length) | (seed >> 1);
        }
    }
}
