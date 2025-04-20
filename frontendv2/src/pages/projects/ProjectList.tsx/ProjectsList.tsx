import React, { useContext, useState, useEffect } from "react";
import { ProjectsContext } from "../../../contexts/ProjectsContext";
import { Project } from "../../../types/project";
//import ProjectForm from "../ProjectForm";
import "./ProjectList.css";
import { useOutletContext } from "react-router-dom";
import ProjectFormModal from "../../../components/modals/ProjectFormModal";
import Header from "../../../partials/sections/Header/Header";

type LayoutContext = {
   triggerAdd: boolean;
   setTriggerAdd: (value: boolean) => void;
   activeTab: "InProgress" | "Completed";
   setActiveTab: (tab: "InProgress" | "Completed") => void;
};

const ProjectsList: React.FC = () => {
   const context = useContext(ProjectsContext);

   const [activeProjectForm, SetActiveProjectForm] =
      useState<Partial<Project> | null>(null);
   const [sortBy, setSortBy] = useState<string>("startDate");
   const [sortDirection, setSortDirection] = useState<string>("asc");
   const [dropdownOptionId, setDropdownOptionId] = useState<string | null>(
      null
   );
   const { triggerAdd, setTriggerAdd, activeTab, setActiveTab } =
      useOutletContext<LayoutContext>();

   if (!context) {
      throw new Error("ProjectsContext must be used within a ProjectsProvider");
   }

   const {
      projects,
      loading,
      error,
      createProject,
      updateProject,
      deleteProject,
   } = context;

   useEffect(() => {
      if (triggerAdd) {
         SetActiveProjectForm({});
         setTriggerAdd(false);
      }
   }, [triggerAdd, setTriggerAdd]);

   useEffect(() => {
      context.fetchProjects?.(sortBy, sortDirection);
   }, [sortBy, sortDirection]);

   const handleSave = async (data: Partial<Project>) => {
      const { status, client, owner, ...safeData } = data;

      if (data.id) {
         await updateProject(data.id, safeData);
      } else {
         await createProject({ ...(safeData as any), statusId: 1 });
      }
      SetActiveProjectForm(null);
   };

   if (loading) return <p>Loading projects...</p>;
   if (error) return <p>Error: {error}</p>;

   const inProgressProjects = projects.filter(
      (project) => project.status?.statusName === "In Progress"
   );
   const completedProjects = projects.filter(
      (project) => project.status?.statusName === "Completed"
   );
   const renderProjects = (list: Project[]) => (
      <div className="projects-grid">
         {list.map((project) => (
            <div
               key={project.id}
               className="project-card"
               onClick={() => setDropdownOptionId(null)}
            >
               <div className="card-header">
                  <h3>{project.projectName}</h3>
                  <div className="dropdown-wrapper">
                     <button
                        className="dropdown-toggle"
                        onClick={(e) => {
                           e.stopPropagation();
                           setDropdownOptionId(
                              dropdownOptionId === project.id
                                 ? null
                                 : project.id
                           );
                        }}
                     >
                        ⋯
                     </button>
                     {dropdownOptionId === project.id && (
                        <div
                           className="dropdown-menu"
                           onClick={(e) => e.stopPropagation()}
                        >
                           <button
                              onClick={() => {
                                 SetActiveProjectForm(project);
                                 setDropdownOptionId(null);
                              }}
                           >
                              ✏️ Edit
                           </button>
                           <button
                              onClick={() => {
                                 if (
                                    confirm(
                                       "Are you sure you want to delete this project?"
                                    )
                                 ) {
                                    deleteProject(project.id);
                                 }
                                 setDropdownOptionId(null);
                              }}
                           >
                              🗑 Delete
                           </button>
                        </div>
                     )}
                  </div>
               </div>

               <p>{project.description}</p>
               <p>
                  <strong>Start:</strong>{" "}
                  {new Date(project.startDate).toLocaleDateString()}
               </p>
               <p>
                  <strong>End:</strong>{" "}
                  {new Date(project.endDate).toLocaleDateString()}
               </p>
               <p>
                  <strong>Budget:</strong>{" "}
                  {project.budget ? `$${project.budget}` : "N/A"}
               </p>
               <p>
                  <strong>Status:</strong> {project.status?.statusName || "N/A"}
               </p>
               <p>
                  <strong>Client:</strong> {project.client?.clientName || "N/A"}
               </p>
               <p>
                  <strong>Owner:</strong> {project.owner?.fullName || "N/A"}
               </p>
            </div>
         ))}
      </div>
   );

   return (
      <>
         <Header
            onAddProject={() => setTriggerAdd(true)}
            activeTab={activeTab}
            setActiveTab={setActiveTab}
            inProgressCount={inProgressProjects.length}
            completedCount={completedProjects.length}
         />

         <div className="sort-controls">
            <label>
               Sort by:&nbsp;
               <select
                  value={sortBy}
                  onChange={(e) => setSortBy(e.target.value)}
               >
                  <option value="startDate">Start Date</option>
                  <option value="endDate">End Date</option>
               </select>
            </label>

            <label style={{ marginLeft: "1rem" }}>
               Direction:&nbsp;
               <select
                  value={sortDirection}
                  onChange={(e) => setSortDirection(e.target.value)}
               >
                  <option value="asc">Ascending</option>
                  <option value="desc">Descending</option>
               </select>
            </label>
         </div>
         {activeTab === "InProgress" ? (
            <>
               <h2>📋 In Progress</h2>
               {inProgressProjects.length > 0 ? (
                  renderProjects(inProgressProjects)
               ) : (
                  <p>No ongoing Projects.</p>
               )}
            </>
         ) : (
            <>
               <h2>✅ Completed</h2>
               {completedProjects.length > 0 ? (
                  renderProjects(completedProjects)
               ) : (
                  <p>No complete projects yet.</p>
               )}
            </>
         )}

         {activeProjectForm && (
            <ProjectFormModal
               initialData={activeProjectForm}
               onSave={handleSave}
               onClose={() => SetActiveProjectForm(null)}
            />
         )}
      </>
   );
};

export default ProjectsList;
