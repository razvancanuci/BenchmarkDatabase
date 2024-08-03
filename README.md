# INTEGER vs UUID (GUID) vs ULID in POSTGRESQL

In this project there are insert and query benchmarks on postgresql database on different primary key types:

- ULID
- ULID Binary
- UUID (GUID)
- INTEGER

The result from my machine are the following:

INSERT:
| Method                  | Size  | Mean     | Error    | StdDev   | Gen0       | Gen1       | Gen2       | Allocated |
|-------------------------|-------|----------|----------|----------|------------|------------|------------|-----------|
| Insert_TableInt         | 10000 | 341.1 ms | 4.81 ms  | 4.49 ms  | 5000.0000  | 2000.0000  | 1000.0000  | 43.41 MB  |
| Insert_TableGuid        | 10000 | 265.8 ms | 3.50 ms  | 3.10 ms  | 5000.0000  | 3000.0000  | 1000.0000  | 43.66 MB  |
| Insert_TableUlid        | 10000 | 302.0 ms | 4.46 ms  | 4.38 ms  | 5000.0000  | 3000.0000  | 1000.0000  | 43.88 MB  |
| Insert_TableUlidBinary  | 10000 | 256.5 ms | 2.86 ms  | 2.54 ms  | 5000.0000  | 3000.0000  | 1000.0000  | 44.05 MB  |

Conclusion: integer is the most memory efficient, but uuid si the most time efficient

QUERY:
| Method                  | Size  | Mean     | Error    | StdDev   | Gen0       | Gen1       | Gen2       | Allocated |
|-------------------------|-------|----------|----------|----------|------------|------------|------------|-----------|
| Query_TableInt          | 10000 | 4.406 ms | 0.0681 ms| 0.0568 ms| 312.5000   | 117.1875   | 39.0625    | 2.36 MB   |
| Query_TableGuid         | 10000 | 4.401 ms | 0.0866 ms| 0.1157 ms| 296.8750   | 109.3750   | 46.8750    | 2.44 MB   |
| Query_TableUlid         | 10000 | 5.642 ms | 0.0863 ms| 0.0721 ms| 500.0000   | 156.2500   | 31.2500    | 3.97 MB   |
| Query_TableUlidBinary   | 10000 | 4.754 ms | 0.0915 ms| 0.0856 ms| 421.8750   | 140.6250   | 46.8750    | 3.2 MB    |

Conclusion: pretty much the same as the insert results

Looks like ULID is not a good option for postgresql databases at this moment
