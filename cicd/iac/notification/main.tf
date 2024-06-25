resource "google_app_engine_standard_app_version" "notification_api" {
  service  = "default"
  version_id = "v1"
  runtime    = "dotnet7"

  deployment {
    files {
      source_url = "https://storage.googleapis.com/${var.project_id}-notification-events/notification-api.zip"
      sha1_sum   = "1b2c3d4e5f6g7h8i9j0k"
    }
  }
}

resource "google_firestore_index" "notification_index" {
  collection      = "notifications"
  fields {
    field_path  = "timestamp"
    order       = "DESCENDING"
  }
}

resource "google_pubsub_topic" "mongo_events_topic" {
  name = "mongo-events"
}

resource "google_pubsub_subscription" "mongo_events_subscription" {
  name  = "mongo-events-sub"
  topic = google_pubsub_topic.mongo_events_topic.name
  ack_deadline_seconds = 20
}

resource "google_storage_bucket_object" "mongo_event_archive" {
  name   = "mongo_event_archive"
  bucket = google_storage_bucket.notification_events.name

  lifecycle_rule {
    condition {
      age = 30
    }
    action {
      type = "Delete"
    }
  }
}

resource "google_firestore_collection" "notification_events" {
  collection_id = "events"
}
