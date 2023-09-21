import { ChatMockApi } from "./apps/chat/api";
import { ScrumboardMockApi } from "./apps/scrumboard/api";
import { AuthMockApi } from "./common/auth/api";
import { MessagesMockApi } from "./common/messages/api";
import { NavigationMockApi } from "./common/navigation/api";
import { NotificationsMockApi } from "./common/notifications/api";
import { SearchMockApi } from "./common/search/api";
import { ShortcutsMockApi } from "./common/shortcuts/api";
import { UserMockApi } from "./common/user/api";

export const mockApiServices = [
    AuthMockApi,
    ChatMockApi,
    MessagesMockApi,
    NavigationMockApi,
    NotificationsMockApi,
    SearchMockApi,
    ScrumboardMockApi,
    ShortcutsMockApi,
    UserMockApi
];
