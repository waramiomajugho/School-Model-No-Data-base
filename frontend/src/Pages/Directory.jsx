import { useState } from 'react';
import { Link } from 'react-router-dom';
import useDocumentTitle from '../hooks/useDocumentTitle';

export default function Directory({ people, setPeople }) {
  useDocumentTitle('School Directory');

  const [searchQuery, setSearchQuery] = useState("");
  const [selectedRole, setSelectedRole] = useState("All");

  // Delete with a confirmation step 
  const handleDelete = (id, name) => {
    if (window.confirm(`Are you sure you want to delete ${name}?`)) {
      setPeople(people.filter(p => p.id !== id));
    }
  };

  const filteredPeople = people.filter(person => {
    const matchesRole = selectedRole === "All" || person.role === selectedRole;
    const fullName = `${person.firstName} ${person.lastName}`.toLowerCase();
    const matchesSearch = fullName.includes(searchQuery.toLowerCase());
    return matchesRole && matchesSearch;
  });

  return (
    <div className="directory-container">
      <h1>School Directory</h1>
      
      <div className="directory-controls">
        <input 
          type="text" 
          placeholder="Search by name..." 
          value={searchQuery} 
          onChange={(e) => setSearchQuery(e.target.value)}
          className="directory-search-input"
        />
        <select 
          value={selectedRole} 
          onChange={(e) => setSelectedRole(e.target.value)} 
          className="directory-select"
        >
          <option value="All">All Roles</option>
          <option value="Student">Student</option>
          <option value="Teacher">Teacher</option>
        </select>
        <Link to="/people/new" className="btn-primary">
          Add Person
        </Link>
      </div>

      <ul className="directory-list">
        {filteredPeople.map(person => (
          <li key={person.id} className="directory-item">
            <div className="directory-person-info">
              <Link to={`/people/${person.id}`} className="directory-person-name">
                {person.firstName} {person.lastName}
              </Link>
              <span className="directory-person-role">({person.role})</span>
            </div>
            <div className="directory-item-actions">
              <Link to={`/people/edit/${person.id}`} className="btn-edit">Edit</Link>
              <button 
                onClick={() => handleDelete(person.id, `${person.firstName} ${person.lastName}`)} 
                className="btn-delete"
              >
                Delete
              </button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
}