import { User, UserManager, UserManagerSettings } from 'oidc-client';

console.log('foo');

const host = window.location.origin;

//
// Configure the oidc-client.js UserManager.
//
const settings: UserManagerSettings = {
    authority: host,
    client_id: 'socialarts.club',
    loadUserInfo: false,
    response_type: 'token',
    scope: 'openid',
    silentRequestTimeout: 10000,
    silent_redirect_uri: `${host}/Me`
};

const userManager = new UserManager(settings);

if (window !== window.parent) {
    userManager.signinSilentCallback();
}

const getAccessToken = async (): Promise<string> => {
    try {
        let user: User = await userManager.getUser();
        if (user) {
            return user.access_token;
        }

        user = await userManager.signinSilent();
        return user.access_token;
    } catch (err) {
        console.log(err);
    }
};

export default async (input?: Request | string, init?: RequestInit): Promise<Response> => {
    console.log('baz');

    const token = await getAccessToken();

    return fetch(input, init);
};

console.log('bar');