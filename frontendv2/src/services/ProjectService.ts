import { Project, NewProject } from "../types/project";

const API_URL = "https://localhost:7232/api/Projects";
const API_KEY = "DHDHRYCCefewwdsfasdasd23423432dfsdfddadhhhasdhlLKFKKFKFVVNNTSRTTTT";

console.log("API BASE:", import.meta.env.VITE_API_URL);
console.log("API KEY:", import.meta.env.VITE_API_KEY);

const defaultHeaders = {
    "Content-Type": "application/json",
    "X-Api-Key": API_KEY,
};

// ✅ Unsorted fetch
export const getProjects = async (): Promise<Project[]> => {
    const response = await fetch(API_URL, {
        method: "GET",
        headers: defaultHeaders,
    });

    if (!response.ok) {
        throw new Error(`Failed to fetch projects (status ${response.status})`);
    }

    return response.json();
};

// ✅ Sorted fetch
export const getSortedProjects = async (
    sortBy: string = "projectName",
    sortDirection: string = "asc"
): Promise<Project[]> => {
    const response = await fetch(
        `${API_URL}?sortBy=${encodeURIComponent(sortBy)}&sortDirection=${encodeURIComponent(sortDirection)}`,
        {
            method: "GET",
            headers: defaultHeaders,
        }
    );

    if (!response.ok) {
        const raw = await response.text();
        console.error("Bad response from API:", raw);
        throw new Error(`Failed to fetch sorted projects (status ${response.status})`);
    }

    return await response.json();
};

export const updateProject = async (id: string, updateData: Partial<Project>): Promise<Project> => {
    const response = await fetch(`${API_URL}/${id}`, {
        method: "PUT",
        headers: defaultHeaders,
        body: JSON.stringify(updateData),
    });
    return response.json();
};

export const createProject = async (newProject: NewProject): Promise<Project> => {
    const response = await fetch(API_URL, {
        method: "POST",
        headers: defaultHeaders,
        body: JSON.stringify(newProject),
    });

    if (!response.ok) {
        throw new Error(`Failed to create project (Status ${response.status})`);
    }

    return response.json();
};

export const deleteProject = async (id: string): Promise<void> => {
    const response = await fetch(`${API_URL}/${id}`, {
        method: "DELETE",
        headers: defaultHeaders,
    });

    if (!response.ok) {
        throw new Error(`Failed to delete project (Status ${response.status})`);
    }
};
