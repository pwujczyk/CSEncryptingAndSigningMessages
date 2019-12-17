Encrypting and signing messages are two methods which uses asymmetric cryptography. Both functions use the same algorithm. Most important in the asymmetric algorithm is that it uses one way function which is simple to calculate in one way but difficult to reverse. Simple example of this kind of method is modulo from number. It is very easy to calculate 46 % 3 = 1, but impossible to guess what is the x in the equation x % 3 = 1.

To perform encryption or sign message we need to have two keys: private and public. Both keys have to be related to each over.

# Encrypting messages #

If sender (A) want to encrypt message and sent it to recipient (B) we should use his recipient public key and using his public key perform one way function. This operation will produce Encrypted message. Recipient (B) using his private key perform the same operation as sender (A) but as a parameter provides encrypted message and his private key. As a result he will receive decrypted message.

# Signing messages #

Signing messages uses the same implementation of the one-way function but as parameters it provides message and private key: If sender want to sign the message it uses private key and as a result it receives signature. The signature and message should be together send to the recipient (B). Recipient can take the signature and using the public key from the sender (A) decrypt signature and receive message. Message send by recipient and message decrypted from the signature should be then compared.


More information:  http://cryptoslides.tech/encrypting-and-signing-messages/
