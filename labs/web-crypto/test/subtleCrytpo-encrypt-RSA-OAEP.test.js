//
// See https://developer.mozilla.org/en-US/docs/Web/API/SubtleCrypto/encrypt
//

//
// Takes a string and encodes it as a UTF-8 array of bytes.
//
const encodeStringToUTF8 = (domString) => {
    const encoder = new TextEncoder();
    return encoder.encode(domString);
}

//
// Takes an UFT-8 array of bytes and returns a string.
//
const decodeStringFromUTF8 = (array) => {
    const decoder = new TextDecoder();
    return decoder.decode(array);
}

describe('window.crypto.subtle exploratory testing', () => {
    describe('encrypting and decrypting a message', () => {
        it('works with RSA-OAEP', async () => {
            // arrange
            const messageOriginalDOMString = 'This is the message';

            // act

            //
            // 1. encode the original data
            //

            const messageUTF8 = encodeStringToUTF8(messageOriginalDOMString);

            console.log(messageUTF8);

            //
            // 2. configure the encryption algorithm to use
            //

            const algorithm = {
                name: 'RSA-OAEP',
            };

            //
            // 3. Generate/fetch the cryptographic keys
            //

            await window.crypto.subtle.generateKey(
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

                const messageDecryptedDOMString = decodeStringFromUTF8(decryptedMessage);

                // assert
                assert.equal(
                    messageOriginalDOMString,
                    messageDecryptedDOMString);
            });
        });
    });
});
