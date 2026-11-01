import { useState } from 'react';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import Header from './Components/Header';
import FilterBar from './Components/FilterBar';
import PersonList from './Components/PersonList';
import PersonDetail from './Pages/PersonDetail';
import PersonForm from './Pages/PersonForm';
import { schoolData } from './data';


function DirectoryView({ people, setPeople }) {
  const [searchQuery, setSearchQuery] = useState("");
  const [selectedRole, setSelectedRole] = useState("All");
  const [sortBy, setSortBy] = useState("name");

  // 1. Filter by Role
  const roleFiltered = selectedRole === "All" 
    ? people 
    : people.filter(person => person.role === selectedRole);

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
      return (a.age || 0) - (b.age || 0);
    } else if (sortBy === "role") {
      return a.role.localeCompare(b.role);
    }
    return 0;
  });

  // Delete handler with state update
  const handleDelete = (id, name) => {
    if (window.confirm(`Are you sure you want to delete ${name}?`)) {
      setPeople(people.filter(p => p.id !== id));
    }
  };

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

        <div className="directory-actions-bar">
          <p className="results-count">
            Showing <strong>{finalFilteredPeople.length}</strong> {finalFilteredPeople.length === 1 ? 'person' : 'people'}
          </p>
          <Link to="/people/new" className="btn-primary">
            Add New Person
          </Link>
        </div>

        <PersonList people={finalFilteredPeople} onDelete={handleDelete} />
      </main>
    </div>
  );
}

export default function App() {
  // Lifting state up: centralized data source for the entire app (
  const [people, setPeople] = useState(schoolData);

  return (
    <BrowserRouter>
      <Routes>
        {/* Route 1: The Directory (Root) */}
        <Route 
          path="/" 
          element={<DirectoryView people={people} setPeople={setPeople} />} 
        />

        {/* Route 2: The Person Detail Page */}
        <Route 
          path="/people/:id" 
          element={<PersonDetail people={people} />} 
        />

        {/* Route 3: The Add / Edit Form Routes */}
        <Route 
          path="/people/new" 
          element={<PersonForm people={people} setPeople={setPeople} />} 
        />
        <Route 
          path="/people/edit/:id" 
          element={<PersonForm people={people} setPeople={setPeople} />} 
        />
      </Routes>
    </BrowserRouter>
  );
}