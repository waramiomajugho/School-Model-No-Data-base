export default function FilterBar({ searchQuery, setSearchQuery, selectedRole, setSelectedRole, sortBy, setSortBy }) {
  const roles = ["All", "Student", "Teacher", "Principal"];

  return (
    <div className="filter-bar">
      <input
        type="text"
        className="search-input"
        placeholder="Search by name (e.g., Alice, Bob)..."
        value={searchQuery}
        onChange={(e) => setSearchQuery(e.target.value)}
      />

      <div className="filter-bottom-row">
        <div className="filter-buttons">
          {roles.map((role) => (
            <button
              key={role}
              onClick={() => setSelectedRole(role)}
              className={`filter-btn ${selectedRole === role ? "active" : ""}`}
            >
              {role === "All" ? "All Members" : `${role}s`}
            </button>
          ))}
        </div>

        <div className="sort-container">
          <label className="sort-label">Sort by:</label>
          <select 
            value={sortBy} 
            onChange={(e) => setSortBy(e.target.value)}
            className="sort-select"
          >
            <option value="name">Name (A-Z)</option>
            <option value="age">Age</option>
            <option value="role">Role</option>
          </select>
        </div>
      </div>
    </div>
  );
}