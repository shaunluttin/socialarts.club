import authFetch from './authFetch';
import { Tool } from "./components/ToolsList";

// TODO Set up a better configuration system.
const origin = window.location.origin;
const apiBase = `${origin}/api`;

export const getTools = async (): Promise<Tool[]> =>
    authFetch(`${apiBase}/tools`).then((response) => response.json());