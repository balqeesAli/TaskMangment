function populateTasks() {
  const accountId = JSON.parse(localStorage.getItem("userData")).id;

  fetch(`https://localhost:7226/api/Task/getList/${accountId}`, {
    method: "GET",
    headers: {
      Accept: "application/json",
    },
  })
    .then((response) => {
      if (!response.ok) {
        throw new Error("Failed to fetch data");
      }
      return response.json();
    })
    .then((data) => {
      const tableBody = document.querySelector("table tbody");
      tableBody.innerHTML = "";

      data.body.forEach((task) => {
        const row = document.createElement("tr");
        row.innerHTML = `
                <td>${task.taskNo}</td>
                <td>${task.title}</td>
                <td>${task.summary}</td>
                <td>${task.status}</td>
                <td>  
                    <input type="button" value="Edit" id="primary" onclick="editTask('${task.taskId}', '${task.title}', '${task.summary}', '${task.status}')">
                    <input type="button" value="Delete" class="delete-btn" data-task-id="${task.taskId}">
                </td>
            `;
        tableBody.appendChild(row);
      });
    })
    .catch((error) => {
      console.error("Error fetching data:", error);
    });
}

function editTask(taskId, title, summary, status) {
  localStorage.setItem(
    "editTask",
    JSON.stringify({ taskId, title, summary, status })
  );
  window.location.href = "updateTask.html";
}

populateTasks();
