import { Client } from "../types/project";


export const getClients = async (): Promise<Client[]> => {
       const response = await fetch("https://localhost:7232/api/Client", {
       headers: {
          "Content-Type": "application/json",
          "X-Api-Key": "DHDHRYCCefewwdsfasdasd23423432dfsdfddadhhhasdhlLKFKKFKFVVNNTSRTTTT", // if needed
       },
    });

    if (!response.ok) throw new Error("Failed to fetch clients");
    return response.json();
}