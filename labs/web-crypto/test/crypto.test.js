//
// See https://developer.mozilla.org/en-US/docs/Web/API/SubtleCrypto/encrypt
//
describe('window.crypto.subtle exploratory testing', () => {
    describe('encrypting and decrypting a message', () => {
        it('works with AES-CTR', async () => {
            // arrange
            const messageOriginalDOMString = 'This is the message';

            // act
            const encoder = new TextEncoder();
            const decoder = new TextDecoder();

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
            // the same counter is required for encryption AND decryption
            //
            const counter = window.crypto.getRandomValues(new Uint8Array(16));

            const algorithm = {
                name: 'AES-CTR',
                counter,
                length: 64
            };

            const messageUTF8 = encoder.encode(messageOriginalDOMString);
            const messageEncryptedUTF8 = await window.crypto.subtle.encrypt(
                algorithm,
                key,
                messageUTF8,
            );

            const messageDecryptedUTF8 = await window.crypto.subtle.decrypt(
                algorithm,
                key,
                messageEncryptedUTF8,
            );

            const messageDecryptedDOMString = decoder.decode(messageDecryptedUTF8);

            // assert
            assert.equal(messageOriginalDOMString, messageDecryptedDOMString);
        });
    });
});
