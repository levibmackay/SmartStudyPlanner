# Smart Study Planner - Software Design Document

## 1. Project Overview and Objectives
The **Smart Study Planner** is a desktop-based C# application designed to help college students manage their academic workload. It goes beyond simple to-do lists by integrating course schedules, assignment tracking, and intelligent study session generation.

### Objectives:
*   **Organization:** Centralize all academic responsibilities (classes, deadlines, grades).
*   **Efficiency:** Automatically generate study schedules based on assignment difficulty and due dates.
*   **Proactive Planning:** Provide grade prediction to help students prioritize their efforts.
*   **Accessibility:** Simple, intuitive interface for busy students.

---

## 2. Recommended Application Architecture
A **Layered Architecture** is recommended to keep the code organized and maintainable.

*   **Presentation Layer (UI):** Handles user interaction (WPF or WinForms).
*   **Business Logic Layer (BLL):** Contains the "brains" of the app (scheduling algorithms, grade calculations).
*   **Data Access Layer (DAL):** Manages saving and loading data (Database interactions).
*   **Models:** Shared data structures across all layers.

---

## 3. Core Classes and Data Models

### `Course`
*   `Guid Id`: Unique identifier.
*   `string Name`: e.g., "Data Structures".
*   `string Professor`: Name of the instructor.
*   `List<Assignment> Assignments`: Assignments linked to this course.
*   `Schedule WeeklySchedule`: When the class meets.

### `Assignment`
*   `Guid Id`: Unique identifier.
*   `string Title`: e.g., "Final Project".
*   `DateTime DueDate`: Deadline.
*   `double Weight`: Percentage of the total grade (e.g., 0.20 for 20%).
*   `int Difficulty`: Scale of 1-10 (used for AI scheduling).
*   `bool IsCompleted`: Progress tracker.

### `StudySession`
*   `DateTime StartTime`: When to start studying.
*   `TimeSpan Duration`: Length of the session.
*   `Guid AssignmentId`: Which assignment this session is for.

---

## 4. User Interface Layout and Screens

1.  **Dashboard:** High-level view of upcoming deadlines, today's classes, and the next suggested study session.
2.  **Course Manager:** Add/Edit/Delete courses and view course-specific details.
3.  **Assignment Tracker:** A kanban-style or list-based view of all tasks, sortable by deadline or priority.
4.  **Calendar View:** Visual representation of the week, combining class times and study blocks.
5.  **Grade Predictor:** A "What-If" calculator where students enter potential scores to see their impact on the final grade.

---

## 5. Database Structure and Relationships
**SQLite** is recommended for a local-first desktop application. It requires no server and is highly reliable.

### Relationships:
*   **Course (1) -> (*) Assignment:** A course has many assignments.
*   **Assignment (1) -> (*) StudySession:** One assignment might require multiple study blocks.
*   **Course (1) -> (1) Schedule:** Each course has a recurring weekly time slot.

---

## 6. Algorithms needed for Scheduling and Grade Prediction

### AI-Generated Study Schedule (Greedy Approach)
1.  **Calculate Priority Score:** `Priority = (Difficulty / DaysRemaining)`.
2.  **Identify Free Blocks:** Scan the user's calendar for gaps between classes and sleep.
3.  **Allocate Time:** Sort assignments by Priority and fill free blocks until the assignment difficulty (work hours required) is met.

### Grade Prediction (Weighted Average)
*   `Current Grade = Σ (Earned Score * Weight) / Σ (Weight of Completed Tasks)`
*   `Predicted Final = (Current Weighted Sum) + (Predicted Score * Remaining Weight)`

---

## 7. Step-by-Step Implementation Roadmap

1.  **Phase 1: Foundation (Week 1)**
    *   Set up project structure and Models.
    *   Implement basic SQLite database using Entity Framework Core.
2.  **Phase 2: Basic UI (Week 2)**
    *   Create "Add Course" and "Add Assignment" forms.
    *   Implement list views to display data.
3.  **Phase 3: Core Logic (Week 3)**
    *   Implement the Grade Calculator.
    *   Implement simple sorting for assignments.
4.  **Phase 4: Intelligent Features (Week 4)**
    *   Develop the Study Session generation algorithm.
    *   Build the Weekly Calendar visual component.

---

## 8. Suggested Folder Structure
```text
SmartStudyPlanner/
├── src/
│   ├── SmartStudyPlanner.UI/         # WPF/WinForms Project
│   │   ├── Views/                    # XAML Files
│   │   ├── ViewModels/               # Logic for the UI
│   ├── SmartStudyPlanner.Core/       # Class Library
│   │   ├── Models/                   # Data structures
│   │   ├── Services/                 # BLL (Scheduling, Grades)
│   ├── SmartStudyPlanner.Data/       # Class Library
│   │   ├── AppDbContext.cs           # EF Core Context
│   │   ├── Repositories/             # DAL
├── tests/                            # Unit tests for algorithms
├── docs/                             # Documentation and assets
└── SmartStudyPlanner.sln
```

---

## 9. Recommended Technologies and Libraries
*   **Language:** C# 12 / .NET 8
*   **Framework:** **WPF (Windows Presentation Foundation)** for a modern desktop look.
*   **ORM:** **Entity Framework Core (EF Core)** for database management.
*   **Database:** **SQLite**.
*   **Helper Libraries:**
    *   `Newtonsoft.Json`: For importing schedules (ICS/JSON).
    *   `LiveCharts`: For visualizing grade trends.

---

## 10. Future Features and Scalability
*   **Cloud Sync:** Sync data with a Firebase or Azure backend.
*   **Import/Export:** Support for Google Calendar or Canvas API.
*   **Mobile Companion:** A Xamarin or Maui app for on-the-go tracking.
*   **Focus Timer:** Integrated Pomodoro timer for study sessions.
