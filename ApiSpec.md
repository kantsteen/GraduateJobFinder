# API Spec
This API is for both human users and their agents. Anyone who's looking for a job is free to use it for their own benefit.

## Endpoints

### GET /api/jobpostings
- Returns all job postings as a list of JobPostingDto data transfer objects
- The URL query parameter `?language=<language>` filters job postings and returns a list of JobPostingDtos tagged with that programming language
  - The parameter can be repeated and several languages means OR, e.g. `?language=java&language=python` means job postings containing either Java OR Python are returned
  - Upper/lower case doesn't matter in this query parameter
  - No matches for the parameter returns `200 OK` and empty array `[]` 
  - Special characters must be URL-encoded, e.g. `c#` is written `c%23` and `c++` is written `c%2B%2B`


### GET /api/jobpostings/{id}
- Returns a JobPostingDto object with the specified id
- Returns `200 OK` if found or `404 Not Found`


### GET /api/programminglanguages
- Returns all programming languages as ProgrammingLanguageDto objects containing an id and a name



## Data transfer objects

### JobPostingDto
```json
{
  "id": 1,
  "companyName": "Novo Nordisk",
  "title": "Senior software engineer",
  "description": "You will work as a senior software engineer",
  "location": "Copenhagen",
  "date": "2026-09-07T00:00:00",
  "url": "https://www.novonordisk.com/careers.html",
  "programmingLanguages": [{ "name": "c#" }, { "name": "python" }]
}
```

### ProgrammingLanguageDto
```json
{ "id": 1, "name": "c#" }
```


## Other
- Adding, changing and deleting data: requires a login first, so the API is read-only until then.