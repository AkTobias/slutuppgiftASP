
import {Status} from "../types/project"
const API_KEY =
      "DHDHRYCCefewwdsfasdasd23423432dfsdfddadhhhasdhlLKFKKFKFVVNNTSRTTTT";

export const getStatuses = async (): Promise<Status[]> => {
    const response = await fetch("https://localhost:7232/api/statuses", {
      headers: {
        "Content-Type": "application/json",
        "X-Api-Key": API_KEY,
      },
    });
  
    if (!response.ok) {
      throw new Error(`Failed to fetch statuses (status ${response.status})`);
    }
  
    return response.json();
  };