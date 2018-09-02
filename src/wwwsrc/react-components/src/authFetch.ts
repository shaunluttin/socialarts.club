import { User, UserManager, UserManagerSettings } from 'oidc-client';

const settings: UserManagerSettings = {}; 
const userManager = new UserManager(settings);

console.log('foo');

let user: User;
userManager.getUser()
    .then((response) => user = response)
    .catch((err) => console.log(err));

export default (input?: Request | string, init?: RequestInit) : Promise<Response> => {
    console.log('baz');
    // get the access token from local storage if it exists
    // otherwise, perform a silent sign in to get the access token
    return fetch(input, init);
};

console.log('bar');