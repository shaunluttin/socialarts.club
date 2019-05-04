# Run the Tests

Open test.html in Firefox to view the test results.

    C:\dev\shaunluttin\socialarts.club\labs\web-crypto\test\test.html

# Standard Encrypt/Decrypt Steps

1. Encode the original data.
2. Configure the encryption algorithm to use.
3. Generate/fetch the cryptographic key(s) to use.
4. Run the encryption algorithm with the key and data.
4. Run the deencryption algorithm with the key and cypher text
4. Decode the decrypted data.

This could be a template method to support a variety of algorithms.

# Questions

Why encode to bits before encypting the text?

* Most if not all encryption algorithms operate on bits not characters.

# WebCrypto API

https://developer.mozilla.org/en-US/docs/Web/API/Web_Crypto_API

* The `Crypto` interface is deprecated (it was poorly defined).
* The `SubtleCrypto` interface replace it.
* Access it via `Crypto.subtle`.

https://developer.mozilla.org/en-US/docs/Web/API/SubtleCrypto/encrypt

* `SubtleCrypto` offers the `encrypt` method.
* It supports four encryption `algorithm`: 
    * RSA-OAEP
    * AES (three modes: CTR, CBC, GCM)
* It also accepts a cryptographic `key` and `data` payload.
* It returns an array buffer.

RSA is a public-key cryptosystem.
* the public key encrypts, the private key decrypts
* anyone can sign; only authorized receipient(s) can decrypt
* the private key signs; the public key validates the signature
* only authorized senders can sign; anyone can verify the sender
* secret club with two levels (many soldiers, one general)

AES is symmetric key 
* GCM mode provides built-in *authenticated encryption*
* The same key encrypts and decrypts
* secret club of equals (secret language like Pig Latin)

[Public key encryption might be appropriate for our use case so that our application can encrypt end-user data without having to prompt the end
user each time for the user's private key.]