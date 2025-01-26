
# FitnessWorkout API

FitnessWorkout API is an educational project that allows users to create, update, delete, and view workouts and exercises. The project utilizes PostgreSQL for data storage and implements a "many-to-many" relationship between workouts and exercises.

Each exercise can be part of multiple workouts, and each workout can include multiple exercises. With modern tools and approaches, the API is easily scalable and user-friendly.

----------

## Key Features

-   **CRUD operations for workouts:**
    
    -   Create new workouts.
        
    -   Update workout details.
        
    -   Delete workouts.
        
    -   View a list of all workouts or a specific workout.
        
-   **CRUD operations for exercises:**
    
    -   Create new exercises.
        
    -   Update exercise details.
        
    -   Delete exercises.
        
    -   View a list of all exercises or a specific exercise.
        
-   **Swagger Documentation:**
    
    -   Easy access to API documentation via Swagger UI.
        
-   **Middleware:**
    
    -   Custom error handling middleware improves API usability and provides standardized responses for errors.
        

----------

## Technologies

-   **ASP NET Core (7.0)**
    
-   **PostgreSQL**
    
-   **Entity Framework Core** for database interaction.
    
-   **AutoMapper** for efficient object mapping.
    
-   **Swagger (Swashbuckle)** for automatic API documentation generation.
    

----------

## Project Setup

### System Requirements

-   **.NET SDK** — Version 7.0 or higher.
    
-   **PostgreSQL** — Version 12 or higher.

## Installation and Setup

1.  Clone the repository.
    
2.  Navigate to the project directory.

3.  Restore dependencies.
    
4.  Update the database.
    
5. Add appsettings.json file and config this file:
```json
{
  "ConnectionStrings": {
    "DefaultConnectionString": "Host=your_host;Database=your_database;Username=your_username;Password=your_password"
  }
}
```
Replace `your_host`, `your_database`, `your_username`, and `your_password` with the appropriate PostgreSQL credentials.

6.  Run the application.
 
    

----------
## Future Plans

### Additional Features
- **Search and Filtering:** Add the ability to search exercises or workouts by keywords, categories, or other parameters.
- **Authentication and Authorization:** Implement user registration and login, restricting access to certain resources based on roles.
- **Logging:** Integrate a logging system to track events in the project.
- **Analytics:** Add analytics tools to track the popularity of exercises and workouts.

### Testing
- Write unit tests to verify core functionality.
- Add integration tests to check the interaction between different parts of the project.

---

## License
This project was created for educational purposes and is not intended for commercial use. Use it at your own discretion.


----------

## Contact

If you have any questions or suggestions, feel free to reach out: 
- **GitHub**: [andrunovostavskyi](https://github.com/andrunovostavskyi) 
- **LinkedIn**: https://www.linkedin.com/in/andriy-novostavskyi-073879325/
-  **Email**: novostavskuy@gmail.com
