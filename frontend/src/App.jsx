import { useState } from 'react';
import Header from './Components/Header';
import FilterBar from './Components/FilterBar';
import PersonList from './Components/PersonList';
import { schoolData } from './data';

export default function App() {
  const [searchQuery, setSearchQuery] = useState("");
  const [selectedRole, setSelectedRole] = useState("All");

  const roleFiltered = selectedRole === "All" 
    ? schoolData 
    : schoolData.filter(person => person.role === selectedRole);

  const finalFilteredPeople = roleFiltered.filter(person => {
    const fullName = `${person.firstName} ${person.lastName}`.toLowerCase();
    return fullName.includes(searchQuery.toLowerCase());
  });

  return (
    <div className="app-container">
      <Header />

      <main className="main-content">
        <FilterBar 
          searchQuery={searchQuery} 
          setSearchQuery={setSearchQuery} 
          selectedRole={selectedRole} 
          setSelectedRole={setSelectedRole} 
        />

        <p className="results-count">
          Showing <strong>{finalFilteredPeople.length}</strong> {finalFilteredPeople.length === 1 ? 'person' : 'people'}
        </p>

        <PersonList people={finalFilteredPeople} />
      </main>
    </div>
  );
}