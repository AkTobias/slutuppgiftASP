export interface Owner {
   id: number;
   fullName: string;
}

export const getOwners = async (): Promise<Owner[]> => {
   const response = await fetch("https://localhost:7232/api/owners", {
      headers: {
         "Content-Type": "application/json",
         "X-Api-Key": "DHDHRYCCefewwdsfasdasd23423432dfsdfddadhhhasdhlLKFKKFKFVVNNTSRTTTT", // if needed
      },
   });

   if (!response.ok) throw new Error("Failed to fetch owners");
   return response.json();
};