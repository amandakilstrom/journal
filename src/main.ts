import { invoke } from "@tauri-apps/api/core";

let greetInputEl: HTMLInputElement | null;
let greetMsgEl: HTMLElement | null;

async function greet() {
  if (greetMsgEl && greetInputEl) {
    // Learn more about Tauri commands at https://tauri.app/develop/calling-rust/
    greetMsgEl.textContent = await invoke("greet", {
      name: greetInputEl.value,
    });
  }
}

window.addEventListener("DOMContentLoaded", () => {
  greetInputEl = document.querySelector("#greet-input");
  greetMsgEl = document.querySelector("#greet-msg");
  document.querySelector("#greet-form")?.addEventListener("submit", (e) => {
    e.preventDefault();
    greet();
  });
});

async function checkBackend() {
  const el = document.querySelector("#backend-status");
  try {
    const res = await fetch("http://localhost:5080/health");
    const data = await res.json();
    if (el) el.textContent = `Backend: ${data.status}`;
  } catch {
    if (el) el.textContent = "Backend: unreachable";
  }
}

window.addEventListener("DOMContentLoaded", checkBackend);