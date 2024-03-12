export  function calculateUserAgePlus(dateOfBirth, yearsToAdd){
  if (isNaN(yearsToAdd) || !dateOfBirth || isNaN(new Date(dateOfBirth))) {
    throw new Error("Invalid dateOfBirth format.");
    }

    const birthYear = new Date(dateOfBirth).getFullYear();
    const currentYear = new Date().getFullYear();
    const agePlusFinal = currentYear - birthYear + yearsToAdd;

    return agePlusFinal;
      
}

export function calculateColourFrequency(userData){
  // console.log(userData);
  const colourFrequency = {};

  // give me the frequency of each colour
  for(const user of userData){
    const colour = user.favouriteColour;
    // console.log(colour);
    if(colour){
      colourFrequency[colour] = (colourFrequency[colour] || 0) + 1;
    }
    else{
      continue;
    } 
  }

  // convert colour frequency object to an array of entries
  const colorEntries = Object.entries(colourFrequency);
  // console.log(colorEntries);

  // sort color by frequency (descending) first, then alphabetically
  colorEntries.sort((a, b) => {
    if (b[1] !== a[1]) {
        return b[1] - a[1];
    } else {
        return a[0].localeCompare(b[0]);
    }
});

   return colorEntries;
}
