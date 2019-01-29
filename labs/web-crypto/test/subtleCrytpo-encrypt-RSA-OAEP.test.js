//
// See https://developer.mozilla.org/en-US/docs/Web/API/SubtleCrypto/encrypt
//
describe('window.crypto.subtle exploratory testing', () => {
    describe('encrypting and decrypting a message', () => {
        it('works with RSA-OAEP', async () => {
            // arrange
            const messageOriginalDOMString = 'This is the message';

            // act

            //
            // 1. encode the original data
            //

            const encoder = new TextEncoder();
            const messageUTF8 = encoder.encode(messageOriginalDOMString);

            //
            // 2. configure the encryption algorithm to use
            //

            const algorithm = {
                name: 'RSA-OAEP',
            };

            //
            // 3. Generate/fetch the cryptographic keys
            //

            window.crypto.subtle.generateKey(
                {
                    name: 'RSA-OAEP',
                    modulusLength: 2048,
                    publicExponent: new Uint8Array([1, 0, 1]),
                    hash: 'SHA-256'
                },
                true,
                [
                    'encrypt',
                    'decrypt'
                ]
            ).then(async keyPair => {

                //
                // 4. Run the encryption algorithm with the key and data.
                //

                const encryptedMessage = await window.crypto.subtle.encrypt(
                    algorithm,
                    keyPair.publicKey,
                    messageUTF8);

                //
                // 5. Run the decryption algorithm with the key and cyphertext.
                //

                const decryptedMessage = await window.crypto.subtle.decrypt(
                    algorithm,
                    keyPair.privateKey,
                    encryptedMessage);

                //
                // 6. Decode the decryped data.
                //

                const decoder = new TextDecoder();
                const messageDecryptedDOMString = decoder.decode(decryptedMessage);

                // assert
                assert.equal(
                    messageOriginalDOMString,
                    messageDecryptedDOMString);
            });
        });
    });
});
