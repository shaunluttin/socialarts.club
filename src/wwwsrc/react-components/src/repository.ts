import { Tool } from "./components/ToolsList";
import fetchAuth from './fetchAuth';

// TODO Set up a better configuration system.
const origin = window.location.origin;
const apiBase = `${origin}/api`;

export const getTools = async (): Promise<Tool[]> =>
    fetchAuth(`${apiBase}/tools`).then((response) => response.json());