import PersonCard from './PersonCard';

export default function PersonList({ people }) {
  if (people.length === 0) {
    return (
      <div className="empty-state">
        <p>No school members found matching your search or filter.</p>
      </div>
    );
  }

  return (
    <div>
      {people.map((person) => (
        <PersonCard key={person.id} person={person} />
      ))}
    </div>
  );
}