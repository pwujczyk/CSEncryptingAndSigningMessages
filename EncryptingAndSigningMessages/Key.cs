using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EncryptingAndSigningMessages
{
    class Key
    {
        int ClockSize;
        int PrivateKey;
        int PublicKey;
        public Key(int privateKey, int publicKey, int clockSize)
        {
            this.ClockSize = clockSize;
            this.PrivateKey = privateKey;
            this.PublicKey = publicKey;
        }

        public int[] EncryptMessage(int[] message)
        {
            Console.WriteLine("Perform operation on the input (message) with PublicKey");
            return OneWayFunction(message, PublicKey);
        }

        public int[] DecrpytMessage(int[] encryptedMessage)
        {
            Console.WriteLine("Perform operation on the input (encrpytedMessage) with PrivateKey");
            return OneWayFunction(encryptedMessage, PrivateKey);
        }

        public int[] GenerateSignature(int[] message)
        {
            Console.WriteLine("Perform operation on the input (message) with PrivateKey");
            return OneWayFunction(message, PrivateKey);
        }

        public int[] DecryptSignature(int[]signature)
        {
            Console.WriteLine("Perform operation on the input (signature) with PublicKey");
            return OneWayFunction(signature, PublicKey);
        }

        public int[] OneWayFunction(int[] message, int key)
        {
            int[] result = new int[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                int elementInMessage = message[i];
                BigInteger power = (BigInteger) BigInteger.Pow(elementInMessage, key);
                BigInteger r = (BigInteger)power % ClockSize;
                Console.WriteLine($"Element in message {elementInMessage} power to {key} is {power} and rest from division by {ClockSize} is {r}");
                result[i] = (int) r;
            }
            return result;
        }

        
    }
}
