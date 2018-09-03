import { User, UserManager, UserManagerSettings } from 'oidc-client';


//
// Configure the oidc-client.js UserManager.
//
const host = window.location.origin;
const settings: UserManagerSettings = {
    authority: host,
    client_id: 'socialarts.club',
    loadUserInfo: false,
    response_type: 'id_token token',
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
        // Important: We can only rely on userManager.getUser() if we can
        // be verity that it returns the currently logged in user and not
        // the previously logged in user.

        const user = await userManager.signinSilent();
        return user.access_token;
    } catch (err) {
        // TODO Introduce propper logging.
        // tslint:disable-next-line
        console.log(err);
    }

    return '';
};

export default async (input?: Request | string): Promise<Response> => {
    const token = await getAccessToken();
    const init = {
        headers: {
            Authorization: `Bearer ${token}`,
        },
        method: 'GET',
    };

    return fetch(input, init);
};
