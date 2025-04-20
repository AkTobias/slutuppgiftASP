import React from "react";
import "./Header.css";

interface HeaderProps {
   onAddProject: () => void;
   activeTab: "InProgress" | "Completed";
   setActiveTab: (tab: "InProgress" | "Completed") => void;
   inProgressCount: number;
   completedCount: number;
}

const Header: React.FC<HeaderProps> = ({
   onAddProject,
   activeTab,
   setActiveTab,
   inProgressCount,
   completedCount,
}) => {
   return (
      <header className="app-header">
         <h1 className="app-title">Project Management</h1>

         <div className="tab-row">
            <div className="tab-header">
               <button
                  className={`tab-button ${
                     activeTab === "InProgress" ? "active" : ""
                  }`}
                  onClick={() => setActiveTab("InProgress")}
               >
                  In Progress [{inProgressCount}]
               </button>
               <button
                  className={`tab-button ${
                     activeTab === "Completed" ? "active" : ""
                  }`}
                  onClick={() => setActiveTab("Completed")}
               >
                  Completed [{completedCount}]
               </button>
            </div>

            <button className="tab-button" onClick={onAddProject}>
               Add New Project
            </button>
         </div>
      </header>
   );
};

export default Header;
