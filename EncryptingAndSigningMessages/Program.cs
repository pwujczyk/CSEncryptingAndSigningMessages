using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptingAndSigningMessages
{
    static class Program
    {
        static void Main(string[] args)
        {
            KeyGenerator kg = new KeyGenerator(3, 11, 17);
            Key k = new Key(kg.PrivateKey, kg.PublicKey, kg.PrimaryClock);
            int[] originalMessage = { 1, 2, 3, 4 };
            originalMessage.WriteMessage(nameof(originalMessage));

            Console.WriteLine("Encrypt message");
            var encryptedMessage=k.EncryptMessage(originalMessage);
            encryptedMessage.WriteMessage(nameof(encryptedMessage));
            Console.WriteLine($"Encrypted message for {originalMessage.WriteMessageRaw()} is {encryptedMessage.WriteMessageRaw()}");

            Console.WriteLine("Decrypt message");
            var decryptedMessage=k.DecrpytMessage(encryptedMessage);
            decryptedMessage.WriteMessage(nameof(decryptedMessage));

            
            Console.WriteLine("Generating Signature");
            int[] signature = k.GenerateSignature(originalMessage);
            signature.WriteMessage(nameof(signature));
            Console.WriteLine($"Signature for {originalMessage.WriteMessageRaw()} is {signature.WriteMessageRaw()}");

            Console.WriteLine("Generate message from signature (decrypting signature)");
            int[] messageFromSignature = k.DecryptSignature(signature);
            messageFromSignature.WriteMessage(nameof(messageFromSignature));
            Console.Read();
        }

        static void WriteMessage(this int[] message, string typeOfMessage)
        {
            Console.WriteLine(typeOfMessage);
            Console.WriteLine(WriteMessageRaw(message));
            Console.WriteLine();
        }

        private static string WriteMessageRaw(this int[] message)
        {
            string r = string.Empty;
            foreach (int item in message)
            {
                r+=item + " ";
            }
            return r;
        }
    }
}
