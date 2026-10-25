export default function FilterBar({ searchQuery, setSearchQuery, selectedRole, setSelectedRole }) {
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
    </div>
  );
}