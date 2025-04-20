import React, { useState, useEffect, ReactNode, useMemo } from "react";
import { ProjectsContext } from "./ProjectsContext";
import { NewProject, Project } from "../types/project";
import * as projectService from "../services/ProjectService";

interface ProjectsProviderProps {
   children: ReactNode;
}

export const ProjectsProvider: React.FC<ProjectsProviderProps> = ({
   children,
}) => {
   const [projects, setProjects] = useState<Project[]>([]);
   const [loading, setLoading] = useState<boolean>(false);
   const [error, setError] = useState<string | null>(null);

   const fetchProjects = async (
      sortBy = "projectName",
      sortDirection = "asc"
   ) => {
      setLoading(true);
      setError(null);
      try {
         const data = await projectService.getSortedProjects(
            sortBy,
            sortDirection
         );
         setProjects(data);
      } catch (err) {
         setError(
            err instanceof Error ? err.message : "An unknown error occurred"
         );
      } finally {
         setLoading(false);
      }
   };

   const updateProject = async (id: string, updatedData: Partial<Project>) => {
      try {
         await projectService.updateProject(id, updatedData);
         await fetchProjects();
      } catch (err) {
         console.error("Error updating project:", err);
         throw err;
      }
   };

   const createProject = async (newProject: NewProject) => {
      try {
         const created = await projectService.createProject(newProject);
         setProjects((prev) => [...prev, created]);
      } catch (err) {
         console.error("Error creating project:", err);
         throw err;
      }
   };

   const deleteProject = async (id: string) => {
      try {
         await projectService.deleteProject(id);
         setProjects((prev) => prev.filter((p) => p.id !== id));
      } catch (err) {
         console.error("Error deleting project:", err);
         throw err;
      }
   };

   useEffect(() => {
      fetchProjects();
      //getProjects();
   }, []);

   return (
      <ProjectsContext.Provider
         value={useMemo(
            () => ({
               projects,
               loading,
               error,
               updateProject,
               createProject,
               deleteProject,
               fetchProjects,
            }),
            [projects, loading, error]
         )}
      >
         {children}
      </ProjectsContext.Provider>
   );
};
