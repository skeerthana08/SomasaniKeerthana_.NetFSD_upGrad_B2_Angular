let db;

// ==========================
// OPEN DATABASE
// ==========================
const request = indexedDB.open("EventDB", 1);

request.onupgradeneeded = function (e) {
    db = e.target.result;
    db.createObjectStore("events", { keyPath: "id" });
};

request.onsuccess = function (e) {
    db = e.target.result;

    // For Events Page (Admin)
    if (document.getElementById("eventList")) {
        displayEvents(true);
    }

    // For Home Page
    if (document.getElementById("homeEvents")) {
        displayEvents(false);
    }
};

// ==========================
// ADD EVENT (UPDATED)
// ==========================
function addEvent() {
    const event = {
        id: document.getElementById("eventId").value,
        name: document.getElementById("eventName").value,
        category: document.getElementById("category").value,
        date: document.getElementById("date").value,
        time: document.getElementById("time").value,
        url: document.getElementById("url").value
    };

    // Validation
    if (!event.id || !event.name || !event.category || !event.date || !event.time || !event.url) {
        alert("Please fill all fields");
        return;
    }

    const tx = db.transaction("events", "readwrite");
    const store = tx.objectStore("events");

    store.add(event);

    tx.oncomplete = function () {
        alert("Event Added Successfully!");

        // Redirect to home page to see updated events
        window.location.href = "index.html";
    };
}

function checkLogin() {
    if (!localStorage.getItem("login")) {
        window.location.href = "login.html";
    }
}

// ==========================
// DISPLAY EVENTS
// ==========================
function displayEvents(isAdmin) {

    const container = isAdmin
        ? document.getElementById("eventList")
        : document.getElementById("homeEvents");

    if (!container) return;

    container.innerHTML = "";

    const tx = db.transaction("events", "readonly");
    const store = tx.objectStore("events");

    let eventsArray = [];

    // Get all events into array
    store.openCursor().onsuccess = function (e) {
        const cursor = e.target.result;

        if (cursor) {
            eventsArray.push(cursor.value);
            cursor.continue();
        } else {

            // 👉 Reverse = latest added first
            eventsArray.reverse();

            // 👉 Home page → only latest 3
            if (!isAdmin) {
                eventsArray = eventsArray.slice(0, 3);
            }

            // 👉 Display events
            eventsArray.forEach(ev => {

                const card = `
                <div class="col-md-4">
                    <div class="card p-3 mb-3">
                        <h5><b>${ev.name}</b></h5>
                        <p><b>ID:</b> ${ev.id}</p>
                        <p><b>Category:</b> ${ev.category}</p>
                        <p><b>Date:</b> ${ev.date}</p>
                        <p><b>Time:</b> ${ev.time}</p>

                        ${
                            isAdmin
                            ? `
                            <a href="${ev.url}" target="_blank" class="btn btn-dark mb-2">Visit Event</a>
                            <button class="btn btn-danger" onclick="deleteEvent('${ev.id}')">Delete</button>
                            `
                            : `
                            <a href="register.html" class="btn btn-primary">Register</a>
                            `
                        }
                    </div>
                </div>
                `;

                container.innerHTML += card;
            });
        }
    };
}

// ==========================
// DELETE EVENT
// ==========================
function deleteEvent(id) {
    const tx = db.transaction("events", "readwrite");
    const store = tx.objectStore("events");

    store.delete(id);

    tx.oncomplete = function () {
        displayEvents(true);
    };
}

// ==========================
// SEARCH EVENT
// ==========================
function searchEvent() {
    const search = document.getElementById("searchInput").value.toLowerCase();
    const container = document.getElementById("eventList");

    container.innerHTML = "";
    let found = false;

    const tx = db.transaction("events", "readonly");
    const store = tx.objectStore("events");

    store.openCursor().onsuccess = function (e) {
        const cursor = e.target.result;

        if (cursor) {
            const ev = cursor.value;

            if (
                ev.name.toLowerCase().includes(search) ||
                ev.category.toLowerCase().includes(search) ||
                ev.id.toLowerCase().includes(search)
            ) {
                found = true;

                container.innerHTML += `
                <div class="col-md-4">
                    <div class="card p-3 mb-3">
                        <h5><b>${ev.name}</b></h5>
                        <p><b>ID:</b> ${ev.id}</p>
                        <p><b>Category:</b> ${ev.category}</p>
                        <p><b>Date:</b> ${ev.date}</p>
                        <p><b>Time:</b> ${ev.time}</p>

                        <a href="${ev.url}" target="_blank" class="btn btn-dark mb-2">Visit Event</a>
                        <button class="btn btn-danger" onclick="deleteEvent('${ev.id}')">Delete</button>
                    </div>
                </div>
                `;
            }

            cursor.continue();
        } else {
            if (!found) {
                container.innerHTML = `<p class="text-center mt-3"><b>No matching events found</b></p>`;
            }
        }
    };
}

// ==========================
// LOGIN
// ==========================
function login() {
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;

    if (email === "admin@upgrad.com" && password === "12345") {
        localStorage.setItem("login", true);
        window.location.href = "events.html";
        return false;
    } else {
        alert("Invalid Credentials");
        return false;
    }
}

// ==========================
// LOGOUT
// ==========================
function logout() {
    localStorage.removeItem("login");
    window.location.href = "login.html";
}

// ==========================
// REGISTER USER
// ==========================
function registerUser() {
    alert("Registration Successful!");
    return false;
}

function logout() {
    localStorage.removeItem("login");
    window.location.href = "login.html";
}