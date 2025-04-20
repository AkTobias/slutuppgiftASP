import React, { useState } from "react";
import { Outlet } from "react-router-dom";
import Logotype from "../../partials/sections/Logotype";
import SideBar from "../../partials/sections/SideBar";

const Layout: React.FC = () => {
   const [triggerAdd, setTriggerAdd] = useState(false);
   const [activeTab, setActiveTab] = useState<"InProgress" | "Completed">(
      "InProgress"
   );

   return (
      <div className="wrapper">
         <Logotype />
         <SideBar />

         <main>
            <Outlet
               context={{ triggerAdd, setTriggerAdd, activeTab, setActiveTab }}
            />
         </main>
      </div>
   );
};

export default Layout;
