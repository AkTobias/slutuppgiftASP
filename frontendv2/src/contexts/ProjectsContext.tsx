import { createContext } from "react";
import { NewProject, Project } from "../types/project";

interface ProjectsContextType {
   projects: Project[];
   loading: boolean;
   error: string | null;

   updateProject: (id: string, updatedData: Partial<Project>) => Promise<void>;
   createProject: (newProject: NewProject) => Promise<void>;
   deleteProject: (id: string) => Promise<void>;
   fetchProjects: (sortBy: string, sortDirection: string) => Promise<void>;
}

export const ProjectsContext = createContext<ProjectsContextType | undefined>(
   undefined
);
