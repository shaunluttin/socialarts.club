import oidc from 'oidc-client';

export default (input?: Request | string, init?: RequestInit) : Promise<Response> => {
    // get the access token from local storage if it exists
    // otherwise, perform a silent sign in to get the access token
    return fetch(input, init);
};
