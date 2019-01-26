//
// See https://developer.mozilla.org/en-US/docs/Web/API/SubtleCrypto/encrypt
//
describe('window.crypto.subtle exploratory testing', () => {
    describe('encrypting and decrypting a message', () => {
        it('works with AES-CTR', async () => {
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

            // AES-CTR: the same counter is required for encryption AND decryption
            const counter = window.crypto.getRandomValues(new Uint8Array(16));
            const algorithm = {
                name: 'AES-CTR',
                counter,
                length: 64
            };

            //
            // 3. Generate/fetch the cryptographic key
            //

            const key = await window.crypto.subtle.generateKey(
                {
                    name: 'AES-CTR',
                    length: 256
                },
                true,
                [
                    'encrypt',
                    'decrypt'
                ]
            );

            //
            // 4. Run the encryption algorithm with the key and data.
            //

            const messageEncryptedUTF8 = await window.crypto.subtle.encrypt(
                algorithm,
                key,
                messageUTF8,
            );

            //
            // 5. Run the decryption algorithm with the key and cyphertext.
            //

            const messageDecryptedUTF8 = await window.crypto.subtle.decrypt(
                algorithm,
                key,
                messageEncryptedUTF8,
            );

            //
            // 6. Decode the decryped data.
            //

            const decoder = new TextDecoder();
            const messageDecryptedDOMString = decoder.decode(messageDecryptedUTF8);

            // assert
            assert.equal(messageOriginalDOMString, messageDecryptedDOMString);
        });
    });
});
