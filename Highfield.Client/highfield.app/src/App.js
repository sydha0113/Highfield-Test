import React, { useState, useEffect } from 'react';
import { calculateUserAgePlus, calculateColourFrequency } from './utils/UserDataProcessor';


import './App.css';
import UserService from './services/userService';

function App() {

  const [userData, setUserData] = useState([]);
  const[ageToAdd, setAgeToAdd] = useState(20); // we initialise 'ageToAdd' to 20, as per request

  // colour frequency
  const[colourFrequency, setColourFrequency] = useState([]);
  

  useEffect(() => {

    const fetchUsers = async()  => {
      try{
        const usersList = await UserService.getUsers();
        setUserData(usersList);

      }
      catch(error){
        console.error(`Error fetching users: ${error}`);
      }
    };
    
    fetchUsers();

  }, []);

// Calculate color frequency
useEffect(() => {
  const calculateColors = () => {
    const colors = calculateColourFrequency(userData);
    console.log(colors);
    setColourFrequency(colors);
  };
   calculateColors();
}, [userData]);


  return (

    <div>
        <h1>User Data with age plus {ageToAdd}</h1>
        <ul>
        {userData.map((user) => (
          <li key={user.id}>
            {`${user.firstName} ${user.lastName} - Age + ${ageToAdd} = ${calculateUserAgePlus(user.dob, ageToAdd)}`}
          </li>
        ))}
        </ul>

<h2>Colour Frequency</h2>
      <ul>
        {colourFrequency.map(([colour, frequency]) => (
          <li key={colour}>
            {`${colour}: ${frequency}`}
          </li>
        ))}
      </ul>

        </div>
  );
}

export default App;
