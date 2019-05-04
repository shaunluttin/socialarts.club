//
// See https://developer.mozilla.org/en-US/docs/Web/API/SubtleCrypto/encrypt
//
describe('window.crypto.subtle exploratory testing', () => {
    describe('encrypting and decrypting a message', () => {
        it('works with AES-GCM', async () => {

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

            // AES-CTR
            const iv = window.crypto.getRandomValues(new Uint8Array(12));
            const algorithm = {
                iv,
                name: 'AES-GCM',
            };

            //
            // 3. Generate/fetch the cryptographic key
            //

            const key = await window.crypto.subtle.generateKey(
                {
                    name: 'AES-GCM',
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

            // Export Key
            const exportedKey = await window.crypto.subtle.exportKey(
                'raw',
                key,
            );

            // Import Key
            const importedKey = await window.crypto.subtle.importKey(
                'raw',
                exportedKey,
                "AES-GCM",
                true,
                [
                    "encrypt",
                    "decrypt"
                ]
            );

            //
            // 5. Run the decryption algorithm with the key and cyphertext.
            //

            const messageDecryptedUTF8 = await window.crypto.subtle.decrypt(
                algorithm,
                importedKey,
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
