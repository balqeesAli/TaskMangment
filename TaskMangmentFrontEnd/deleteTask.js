function deleteTask(taskId) {
  fetch(`https://localhost:7226/api/Task/delete/${taskId}`, {
    method: "DELETE",
    headers: {
      Accept: "application/json",
    },
  })
    .then((response) => {
      if (!response.ok) {
        throw new Error("Failed to delete task");
      }
      alert("Task deleted successfully.");
      populateTasks();
    })
    .catch((error) => {
      console.error("Error deleting task:", error);
    });
}

document.addEventListener("click", function (event) {
  const deleteBtn = event.target.closest(".delete-btn");
  if (deleteBtn) {
    const taskId = deleteBtn.dataset.taskId;
    deleteTask(taskId);
  }
});
