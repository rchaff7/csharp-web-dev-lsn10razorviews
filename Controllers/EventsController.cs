using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("/events/add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);

            return Redirect("/events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/events");
        }

        [Route("/events/edit/{eventId?}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.eventToEdit = EventData.GetById(eventId);
            ViewBag.title = "Edit Event " + ViewBag.eventToEdit.Name + "(id=" + ViewBag.eventToEdit.Id + ")";
            return View();
        }

        [HttpPost("/events/edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            EventData.GetById(eventId).Name = name;
            EventData.GetById(eventId).Description = description;
            return Redirect("/events");
        }
    }
}
