import { useState } from 'react';
import Header from './Components/Header';
import FilterBar from './Components/FilterBar';
import PersonList from './Components/PersonList';
import { schoolData } from './data';

export default function App() {
  const [searchQuery, setSearchQuery] = useState("");
  const [selectedRole, setSelectedRole] = useState("All");
  const [sortBy, setSortBy] = useState("name");

  // 1. Filter by Role
  const roleFiltered = selectedRole === "All" 
    ? schoolData 
    : schoolData.filter(person => person.role === selectedRole);

  // 2. Filter by Search Query
  const searchFiltered = roleFiltered.filter(person => {
    const fullName = `${person.firstName} ${person.lastName}`.toLowerCase();
    return fullName.includes(searchQuery.toLowerCase());
  });

  // 3. Sort the results
  const finalFilteredPeople = [...searchFiltered].sort((a, b) => {
    if (sortBy === "name") {
      return a.firstName.localeCompare(b.firstName);
    } else if (sortBy === "age") {
      return a.age - b.age;
    } else if (sortBy === "role") {
      return a.role.localeCompare(b.role);
    }
    return 0;
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
          sortBy={sortBy}
          setSortBy={setSortBy}
        />

        <p className="results-count">
          Showing <strong>{finalFilteredPeople.length}</strong> {finalFilteredPeople.length === 1 ? 'person' : 'people'}
        </p>

        <PersonList people={finalFilteredPeople} />
      </main>
    </div>
  );
}