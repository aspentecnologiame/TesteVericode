export enum Task {
    New = 0,
    Active = 1,
    Resolved = 2,
    Closed = 3,
    Canceled = 4
}

export const TaskLabelMapping: Record<number, string> = {
    0: "New",
    1: "Active",
    2: "Resolved",
    3: "Closed",
    4: "Canceled"
};