import { Tool } from "./components/ToolsList";

// TODO Set up a better configuration system.
const origin = window.location.origin;
const apiBase = `${origin}/api`;

export const getTools = async (): Promise<Tool[]> =>
    fetch(`${apiBase}/tools`).then((response) => response.json());