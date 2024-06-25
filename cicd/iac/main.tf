provider "google" {
  project = var.project_id
  region  = var.region
}

resource "google_project_service" "enable_services" {
  for_each = toset([
    "container.googleapis.com",  // For GKE
    "sqladmin.googleapis.com",   // For Cloud SQL
    "storage.googleapis.com",    // For GCS
    "appengine.googleapis.com",  // For App Engine
    "firestore.googleapis.com",  // For Firestore
  ])
  service = each.value
}

module "gke" {
  source = "terraform-google-modules/kubernetes-engine/google"
  project_id = var.project_id
  name       = "gke-cluster"
  region     = var.region
  network    = "default"
  subnetwork = "default"
}

module "cloud_sql_customer" {
  source = "terraform-google-modules/sql-db/google"
  name     = "customer-postgres"
  database_version = "POSTGRES_12"
  region = var.region
  project = var.project_id
  settings = {
    tier = "db-f1-micro"
  }
}

module "cloud_sql_campaign" {
  source = "terraform-google-modules/sql-db/google"
  name     = "campaign-postgres"
  database_version = "POSTGRES_12"
  region = var.region
  project = var.project_id
  settings = {
    tier = "db-f1-micro"
  }
}

resource "google_storage_bucket" "notification_events" {
  name          = "${var.project_id}-notification-events"
  location      = var.region
  force_destroy = true
}

resource "google_app_engine_application" "app" {
  project     = var.project_id
  location_id = var.region
}

module "firestore" {
  source = "terraform-google-modules/firestore/google"
  project_id = var.project_id
  location_id = var.region
}
