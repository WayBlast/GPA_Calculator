# A GPA Calculator 
<img width="360" height="522" alt="image" src="https://github.com/user-attachments/assets/bc440fd8-1463-4699-87a8-e19fd9c888d9" />
<img width="360" height="517" alt="image" src="https://github.com/user-attachments/assets/38f07ef0-6d8a-4cb2-bb6d-ca88eda68f06" />

A simple desktop application built with C# and WinForms for calculating and planning your GPA based on ECTS-weighted courses. The app also supports saving and loading data using SQLite.

## Features

- Add courses with:
  - Course name
  - ECTS credits
  - Grade (Danish grading scale)
- Automatic GPA calculation (ECTS-weighted)
- View total ECTS
- Edit course list:
  - Delete individual courses
  - Clear all courses
- Sort courses by:
  - Name
  - ECTS
  - Grade
- Save and load data using SQLite (`courses.db`)
- Planning tools:
  - Set a target GPA and calculate required grade improvements
  - Calculate maximum possible GPA
  - Calculate minimum passing GPA
  - Reset planned grades

## Data Storage

- Uses Microsoft.Data.Sqlite
- Stores data locally in `courses.db`
- Save overwrites previous data
- Load restores previously saved courses

## UI Modes

### Edit Mode
- Add, remove, and sort courses

### Plan Mode
- Set a target GPA
- Simulate grade improvements
- Explore best/worst-case GPA scenarios

## Getting Started

1. Clone the repository
2. Open the project in Visual Studio
3. Build and run the application
4. Start adding your courses

## Notes

- Course names must be unique
- GPA ignores courses without a grade
- Planning modifies grades temporarily (can be reset)
