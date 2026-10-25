[ App.jsx ]
                    (State: searchQuery, roleFilter)
                                │
        ┌───────────────────────┴───────────────────────┐
        ▼                                               ▼
[ Header.jsx ]                                    [ FilterBar.jsx ]
(Title & subtitle)                       (Search Input & Role Filter Buttons)
                                                        │
                                                        ▼
                                                  [ PersonList.jsx ]
                                              (Filters data & renders count)
                                                        │
                                                        ▼
                                                 [ PersonCard.jsx ]
                                           (Conditional rendering per role)





Component Structure (App.jsx, Header.jsx, FilterBar.jsx, PersonList.jsx, PersonCard.jsx): The application is split into 5 distinct single-responsibility files. App holds the centralized state, passing down props to handle user inputs and filtered lists.

Dynamic UI (PersonCard.jsx): Uses conditional rendering (&& and ternaries) inside a single component to dynamically adapt its layout depending on whether the entity is a student, teacher, or principal, avoiding any duplicate card components.

Interactivity & State (useState): Combines a live text search with category filtering buttons so both work together seamlessly without canceling each other out.

User Experience & Polish: Features a live visible count, a clean empty state message for zero results, and unique key props on mapped arrays to ensure zero browser console warnings.                          