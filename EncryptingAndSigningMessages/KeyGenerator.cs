using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptingAndSigningMessages
{
    class KeyGenerator
    {
        int P, Q;
        public int PublicKey;
        public int PrimaryClock
        {
            get
            {
                return P * Q;
            }
        }

        //needed to calculate private key
        int SecondaryClock
        {
            get
            {
                return (P - 1) * (Q - 1);
            }
        }

        int? privateKey = null;
        public int PrivateKey
        {
            get
            {
                if (privateKey.HasValue)
                {
                    return privateKey.Value;
                }
                Console.WriteLine("Trying to find private key for given parameters");
                int i = 1;
                while (true)
                {
                    int x = (PublicKey * i - 1) % SecondaryClock;
                    Console.WriteLine($"{nameof(PublicKey)}: {PublicKey}; {nameof(SecondaryClock)}: {SecondaryClock}; Try {nameof(PrivateKey)}:{i}; X:{x}");
                    if (x == 0)
                    {
                        Console.WriteLine($"Private key for given parametres found:{i}");
                        privateKey = i;
                        return privateKey.Value;
                    }
                    i++;
                }
            }
        }

        public KeyGenerator(int p, int q, int publicKey)
        {
            if (IsPrime(p) && IsPrime(q) == false)
            {
                throw new Exception("Both numbers have to be prime");
            }
            this.P = p;
            this.Q = q;

            if (publicKey <= 1)
            {
                throw new Exception("Public Key have to be greater than 1");
            }
            if (IsPrime(publicKey) == false)
            {
                throw new Exception("Public Key for simplicity have to be prime number");
            }
            if (publicKey > PrimaryClock)
            {
                throw new Exception($"Publick Key have to be smaller then {nameof(PrimaryClock)} ({PrimaryClock})");
            }
            if (PrimaryClock % publicKey == 0)
            {
                throw new Exception("Public key and PublickPrivate key have to be prime number to each over (both common division have to be 1");
            }

            
            this.PublicKey = publicKey;
            PrintParameters();
            var x=PrivateKey;
            PrintParameters();
        }

        private void PrintParameters()
        {
            Console.WriteLine();
            Console.WriteLine($"Prime random number given {nameof(P)}: {this.P} and {nameof(Q)}: {this.Q}");
            Console.WriteLine($"{nameof(PublicKey)} given: {PublicKey}"); 
            Console.WriteLine($"{nameof(PrimaryClock)} calculated as {nameof(P)}*{nameof(Q)}: {PrimaryClock}");
            Console.WriteLine($"{nameof(SecondaryClock)}calculated as ({nameof(P)}-1)*({nameof(Q)}-1): {SecondaryClock}");
            Console.WriteLine($"{nameof(privateKey)}:{privateKey}");
        }

        static bool IsPrime(int n)
        {
            if (n > 1)
            {
                return Enumerable.Range(1, n).Where(x => n % x == 0)
                                 .SequenceEqual(new[] { 1, n });
            }

            return false;
        }
    }
}
